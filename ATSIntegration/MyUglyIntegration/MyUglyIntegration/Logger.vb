Public Class Logger
    Public Sub LogSucess(email As String)
        Console.WriteLine("sucess:" + email)
    End Sub
    Public Sub LogError(email As String, message As String)
        Console.WriteLine("error:" + email + ":" + message)
    End Sub
    Public Sub LogText(message As String)
        Console.WriteLine(message)
    End Sub
End Class
