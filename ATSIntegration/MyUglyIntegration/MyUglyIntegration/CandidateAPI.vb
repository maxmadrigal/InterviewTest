Imports System.Net
Imports System.IO

Public Class CandidateAPI
    Dim myLog As Logger

    Public Const databaseID As String = "MYDBsID"
    Public Sub New()
        myLog = New Logger()
    End Sub

    Public Sub reportAllCandidates()
        Dim result As Boolean = False
        Dim URL As String = String.Format("http://localhost:56145/api/{0}/Candidate/", databaseID)
        Dim sResponse As String = String.Empty
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(URL), HttpWebRequest)
        request.ContentType = "application/json"
        request.Method = "GET"


        Using response As HttpWebResponse = request.GetResponse()
            Using reader As New StreamReader(response.GetResponseStream())
                sResponse = reader.ReadToEnd()
            End Using
            If CInt(response.StatusCode) = 200 Then
                myLog.LogText(sResponse)
            End If
        End Using
    End Sub

    Public Sub CreateCandidate(email As String, firstName As String, lastName As String, phone As String, country As String, stateCode As String, city As String)
        Dim result As Boolean = False
        Dim URL As String = String.Format("http://localhost:56145/api/{0}/Candidate/", databaseID)
        Dim sResponse As String = String.Empty
        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(URL), HttpWebRequest)
        request.ContentType = "application/json"
        request.Method = "POST"
        Using requestStream As Stream = request.GetRequestStream()
            Using stream As Stream = GetCreationContent(email, firstName, lastName, phone, country, stateCode, city)
                stream.Position = 0

                Dim buffer As Byte() = New Byte(CInt(stream.Length)) {}
                stream.Read(buffer, 0, CInt(stream.Length))

                requestStream.Write(buffer, 0, buffer.Length)
            End Using


            requestStream.Flush()
            requestStream.Close()
            requestStream.Dispose()

            Using response As HttpWebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    sResponse = reader.ReadToEnd()
                End Using
                If CInt(response.StatusCode) = 201 Then
                    myLog.LogSucess(sResponse)
                End If
            End Using

        End Using
    End Sub

    Public Function GetCreationContent(email As String, firstName As String, lastName As String, phone As String, country As String, stateCode As String, city As String) As Stream
        Dim stream As Stream = New System.IO.MemoryStream()
        Dim states As Hashtable = GetUnidedStatesCodes()

        If states.ContainsKey(stateCode) Then
            stateCode = states(stateCode).ToString()
        End If

        AddLine(stream, "{")
        AddField(stream, "email", email)
        AddLine(stream, ",")
        AddField(stream, "firstName", firstName)
        AddLine(stream, ",")
        AddField(stream, "lastName", lastName)
        AddLine(stream, ",")
        AddField(stream, "phone", phone)
        AddLine(stream, ",")
        AddLine(stream, """address"":[{")
        AddField(stream, "country", country)
        AddLine(stream, ",")
        AddField(stream, "stateCode", stateCode)
        AddLine(stream, ",")
        AddField(stream, "city", city)
        AddLine(stream, "}]")
        AddLine(stream, "}")

        Return stream
    End Function

    Private Sub AddField(stream As Stream, field As String, Value As String)
        AddLine(stream, String.Format("""{0}"":""{1}""", field, Value))
    End Sub
    Private Sub AddBytes(stream As Stream, ByVal bytes As Byte())
        stream.Write(bytes, 0, bytes.Length)
    End Sub

    Private Sub AddLine(stream As Stream, Value As String)
        If Not String.IsNullOrEmpty(Value) Then
            AddBytes(stream, System.Text.Encoding.UTF8.GetBytes(Value))
        End If
        AddBytes(stream, System.Text.Encoding.UTF8.GetBytes(vbCrLf))
    End Sub

    Private Shared Function GetUnidedStatesCodes() As Hashtable
        Dim ht As New Hashtable
        ht.Add("ALASKA", "AK")
        ht.Add("ALABAMA", "AL")
        ht.Add("ARKANSAS", "AR")
        ht.Add("ARIZONA", "AZ")
        ht.Add("CALIFORNIA", "CA")
        ht.Add("COLORADO", "CO")
        ht.Add("CONNECTICUT", "CT")
        ht.Add("DISTRICT OF COLUMBIA", "DC")
        ht.Add("COLUMBIA", "DC")
        ht.Add("DELAWARE", "DE")
        ht.Add("FLORIDA", "FL")
        ht.Add("GEORGIA", "GA")
        ht.Add("HAWAII", "HI")
        ht.Add("IOWA", "IA")
        ht.Add("IDAHO", "ID")
        ht.Add("ILLINOIS", "IL")
        ht.Add("INDIANA", "IN")
        ht.Add("KANSAS", "KS")
        ht.Add("KENTUCKY", "KY")
        ht.Add("LOUISIANA", "LA")
        ht.Add("MASSACHUSETTS", "MA")
        ht.Add("MARYLAND", "MD")
        ht.Add("MAINE", "ME")
        ht.Add("MICHIGAN", "MI")
        ht.Add("MINNESOTA", "MN")
        ht.Add("MISSOURI", "MO")
        ht.Add("MISSISSIPPI", "MS")
        ht.Add("MONTANA", "MT")
        ht.Add("NORTH CAROLINA", "NC")
        ht.Add("NORTH DAKOTA", "ND")
        ht.Add("NEBRASKA", "NE")
        ht.Add("NEW HAMPSHIRE", "NH")
        ht.Add("NEW JERSEY", "NJ")
        ht.Add("NEW MEXICO", "NM")
        ht.Add("NEVADA", "NV")
        ht.Add("NEW YORK", "NY")
        ht.Add("OHIO", "OH")
        ht.Add("OKLAHOMA", "OK")
        ht.Add("OREGON", "OR")
        ht.Add("PENNSYLVANIA", "PA")
        ht.Add("PUERTO RICO", "PR")
        ht.Add("RHODE ISLAND", "RI")
        ht.Add("SOUTH CAROLINA", "SC")
        ht.Add("SOUTH DAKOTA", "SD")
        ht.Add("TENNESSEE", "TN")
        ht.Add("TEXAS", "TX")
        ht.Add("UTAH", "UT")
        ht.Add("VIRGINIA", "VA")
        ht.Add("VERMONT", "VT")
        ht.Add("WASHINGTON", "WA")
        ht.Add("WISCONSIN", "WI")
        ht.Add("WEST VIRGINIA", "WV")
        ht.Add("WYOMING", "WY")
        Return ht
    End Function
End Class
