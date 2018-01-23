using MyStorage.Models;
using MyStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CandidateController : ApiController
    {
        public CandidateController()
        {
        } 
        //
        // GET: api/Candidate/

        public Candidate[] Get(string databaseId)
        {
            CandidateRepository candidateRepository;
            candidateRepository = new CandidateRepository(databaseId);
            return candidateRepository.GetAll().Values.ToArray();
        }

        // POST api/Candidate
        public HttpResponseMessage Post(string databaseId,NewCandidate value)
        {
            try
            {
                CandidateRepository candidateRepository;
                candidateRepository = new CandidateRepository(databaseId);
                string message = string.Empty;

                if (!candidateRepository.IsValidCandidate(value, out message))
                {
                    var dataErrorResponse = Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, message);

                    return dataErrorResponse;
                }

                Candidate result = candidateRepository.CreateCandidate(value);

                var response = Request.CreateResponse<Candidate>(System.Net.HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception ex)
            {
                var response = Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError,ex);
                return response;
            }
        }


        // PUT api/Candidate/5
        public HttpResponseMessage Put(string databaseId, Candidate value)
        {
            CandidateRepository candidateRepository;
            candidateRepository = new CandidateRepository(databaseId);
            string message = string.Empty;

            if (!candidateRepository.IsValidCandidate(value, out message))
            {
                var dataErrorResponse = Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, message);

                return dataErrorResponse;
            }

            candidateRepository.SaveCandidate(value);

            var response = Request.CreateResponse<Candidate>(System.Net.HttpStatusCode.Accepted, value);
            return response;
        }

        // DELETE api/Candidate/5
        public HttpResponseMessage Delete(string databaseId, string id)
        {
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "This services is not implemented yet, please don't implement this option in your application");
        }
    }
}
