Option Strict Off
Option Explicit On
Imports Solomon.Kernel
Imports VB = Microsoft.VisualBasic
Module INBASE

    Public CSR_XPROJINV As Short
    Dim SQLstmt As String
    Sub doINBASEProcess()
        'compile cursor
        Call sql(CSR_XProjinv, "select top 1 *  from xprojinv")
        SQLstmt = "XINBASETPL_all" + SParm(bpes.UserId) + IParm(IntMin) + IParm(IntMax)
        serr5 = SqlFetch1(c5, SQLstmt, bXINBASETPL)
        With bXPROJINV
            Do While serr5 = 0
                .Crtd_prog = bPJPROJ.crtd_prog
                .Crtd_datetime = bPJPROJ.crtd_datetime
                .Crtd_user = bpes.UserId
                .Descr = bXINBASETPL.Descr
                .Invtid = bXINBASETPL.Invtid
                .Linenbr = bXINBASETPL.Linenbr
                .Project = bPJPROJ.project
                .QtyShip = bXINBASETPL.QtyShip
                .ShipDateAct = bXINBASETPL.ShipDateAct
                .SystemType = bXINBASETPL.SystemType
                .TKO = 1
                Call SInsert1(CSR_XPROJINV, "XPROJINV", bXPROJINV)
                serr5 = SFetch1(c5, bXINBASETPL)
            Loop
        End With
        'at end
        SQLstmt = "xSYSTEMTYPES_INBASETPL" + SParm(bpes.UserId) + SParm(bPJPROJ.project)
        Call sql(c9, SQLstmt)
       
    End Sub
End Module