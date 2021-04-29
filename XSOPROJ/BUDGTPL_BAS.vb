Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB = Microsoft.VisualBasic
Module BUDGTPL

    Public Class BudgTask
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=32) _
        > _
        Public Property Task() As String

            Get
                Return Me.GetPropertyValue("Task")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Task", setval)
            End Set

        End Property
    End Class
    Private bBudgTask As BudgTask = New BudgTask, nBudgTask As BudgTask = New BudgTask
    Public Class Employee
        Inherits SolomonDataObject
        < _
        DataBinding(PropertyIndex:=0, StringSize:=32) _
        > _
        Public Property ID() As String

            Get
                Return Me.GetPropertyValue("ID")
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("ID", setval)
            End Set

        End Property
    End Class
    Private bEmployee As Employee = New Employee, nEmployee As Employee = New Employee
    Public CSR_xBUDGTPL As Short, CSR_PJRevHdr, CSR_PJRevTsk, CSR_PJRevCat As Short

    Dim SQLstmt As String
    Sub doBUDGProcess()

        'compile cursor
        Call sql(CSR_PJRevHdr, "select top 1 *  from PJRevHdr")
        Call sql(CSR_PJRevTsk, "select top 1 * from PJRevTsk")
        Call sql(CSR_PJRevCat, "select top 1 * from PJRevCat")

        With bPJREVHDR
            .Project = bPJPROJ.project
            .RevId = "0001"
            .Revision_Desc = "Budget #1 - Project" + bxProjex.ProjName
            .Post_Period = GetModulePeriod("PA")
            'mod 7/31/14
            SQLstmt = "xSalesOrdSpec" + SParm(bpes.UserId)
            '***select Employee from PJEMPLOY where user_id = @userid
            serr1 = SqlFetch1(c8, SQLstmt, bEmployee)
            .Preparer = bEmployee.id
            .approver = bEmployee.ID
            .RevisionType = "NT"
            .update_type = "A"
            .status = "C"
            Call GetSysDate(.Create_Date)
            .crtd_datetime = .Create_Date
            .crtd_user = bpes.UserId
            .crtd_prog = "XSOPROJ"
            .lupd_datetime = .crtd_datetime
            .lupd_prog = .crtd_prog
            .lupd_user = .crtd_user
            Call SInsert1(CSR_PJRevHdr, "PJRevHdr", bPJREVHDR)
        End With

        SQLstmt = "XBUDGTPL_DistinctTask" + SParm(bpes.UserId)
        serr7 = SqlFetch1(c7, SQLstmt, bBudgTask)
        Do While serr7 = 0
            With bPJREVTSK
                .crtd_datetime = bPJREVHDR.crtd_datetime
                .crtd_user = bpes.UserId
                .crtd_prog = "XSOPROJ"
                .lupd_datetime = .crtd_datetime
                .lupd_prog = .crtd_prog
                .lupd_user = .crtd_user
                .pjt_entity = bBudgTask.Task
                SQLstmt = "pjpent_sall" + SParm(bPJPROJ.project) + SParm(.pjt_entity)
                serr8 = SqlFetch1(c8, SQLstmt, bPJPENT)
                .pjt_entity_desc = bPJPENT.pjt_entity_desc
                .project = bPJPROJ.project
                .revid = "0001"
                Call SInsert1(CSR_PJRevTsk, "PJRevtsk", bPJREVTSK)

                SQLstmt = "xbudgtpl_all" + SParm(bpes.UserId) + SParm(bBudgTask.Task) + SParm(SQLWILDSTRING)
                serr8 = SqlFetch1(CSR_xBUDGTPL, SQLstmt, bxBudgtpl)
                Do While serr8 = 0
                    With bPJREVCAT
                        .Acct = bxBudgtpl.Acct
                        .project = bPJPROJ.project
                        .RevId = "0001"
                        .Units = bxBudgtpl.Units
                        .Rate = bxBudgtpl.Rate_Renamed
                        .Amount = bxBudgtpl.Amount
                        .crtd_datetime = bPJREVHDR.crtd_datetime
                        .crtd_user = bpes.UserId
                        .crtd_prog = "XSOPROJ"
                        .lupd_datetime = .crtd_datetime
                        .lupd_prog = .crtd_prog
                        .lupd_user = .crtd_user
                        .pjt_entity = bBudgTask.Task
                        'new fields in SL2015 mod 3/17/16
                        .ProjCury_Amount = .Amount
                        .ProjCury_Rate = .Rate
                        .ProjCuryEffDate = .lupd_datetime
                        '.ProjCuryId = bpes.BaseCuryID
                        .ProjCuryId = bPJPROJ.ProjCuryId 'mod 8/31/17 this comes from proj template
                        .ProjCuryMultiDiv = "M"
                        .ProjCuryRate = 1
                        Call SInsert1(CSR_PJRevCat, "PJRevCat", bPJREVCAT)
                    End With
                    serr8 = SFetch1(CSR_xBUDGTPL, bxBudgtpl)
                Loop
            End With
            serr7 = SFetch1(c7, bBudgTask)
        Loop
    End Sub
End Module