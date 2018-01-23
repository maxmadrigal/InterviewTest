Module Module1


    Sub Main()
        Dim myApi As New CandidateAPI()

        myApi.reportAllCandidates()

        myApi.CreateCandidate("email1@test.com", "FirstName1", "LastName1", "phone1", "US", "GA", "Atlanta")
        myApi.CreateCandidate("email2@test.com", "FirstName2", "LastName2", "phone2", "US", "CO", "Denver")
        myApi.CreateCandidate("email3@test.com", "FirstName3", "LastName3", "phone3", "US", "IL", "Chicago")
        myApi.CreateCandidate("email4@test.com", "FirstName4", "LastName4", "phone4", "US", "FL", "Orlando")
        myApi.CreateCandidate("email5@test.com", "FirstName5", "LastName5", "phone5", "US", "IN", "Indianapolis")
        myApi.CreateCandidate("email6@test.com", "FirstName6", "LastName6", "phone6", "US", "NE", "Lincoln")
        myApi.CreateCandidate("email7@test.com", "FirstName7", "LastName7", "phone7", "US", "NY", "Albany")
        myApi.CreateCandidate("email8@test.com", "FirstName8", "LastName8", "phone8", "US", "WA", "Seattle")
        myApi.CreateCandidate("email9@test.com", "FirstName9", "LastName9", "phone9", "CA", "Ontario", "Toronto")
        myApi.CreateCandidate("email10@test.com", "FirstName10", "LastName10", "phone10", "CA", "Quebec", "Montreal")

        myApi.reportAllCandidates()

        Console.ReadLine()
    End Sub

End Module
