Public Class NoScrollPanel
    Inherits Panel

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style And Not &H200000
            cp.Style = cp.Style And Not &H100000
            Return cp
        End Get
    End Property
End Class
