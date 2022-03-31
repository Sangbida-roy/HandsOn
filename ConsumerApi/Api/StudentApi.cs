using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IStudentApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>string</returns>
        string ApiStudentCreateStudentPost(StudentBO body);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        string ApiStudentDeleteStudentByIdDelete(int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>string</returns>
        string ApiStudentEditStudentPost(StudentBO body);
        /// <summary>
        ///  
        /// </summary>
        /// <returns>List&lt;StudentBO&gt;</returns>
        List<StudentBO> ApiStudentGetAllStudentsGet();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentBO</returns>
        StudentBO ApiStudentGetStudentByIdGet(int? id);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class StudentApi : IStudentApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public StudentApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StudentApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>string</returns>
        public string ApiStudentCreateStudentPost(StudentBO body)
        {

            var path = "/api/Student/CreateStudent";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentCreateStudentPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentCreateStudentPost: " + response.ErrorMessage, response.ErrorMessage);

            return (string)ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        public string ApiStudentDeleteStudentByIdDelete(int? id)
        {

            var path = "/api/Student/DeleteStudentById";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (id != null) queryParams.Add("id", ApiClient.ParameterToString(id)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentDeleteStudentByIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentDeleteStudentByIdDelete: " + response.ErrorMessage, response.ErrorMessage);

            return (string)ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="body"></param>
        /// <returns>string</returns>
        public string ApiStudentEditStudentPost(StudentBO body)
        {

            var path = "/api/Student/EditStudent";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentEditStudentPost: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentEditStudentPost: " + response.ErrorMessage, response.ErrorMessage);

            return (string)ApiClient.Deserialize(response.Content, typeof(string), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns>List&lt;StudentBO&gt;</returns>
        public List<StudentBO> ApiStudentGetAllStudentsGet()
        {

            var path = "/api/Student/GetAllStudents";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;


            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentGetAllStudentsGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentGetAllStudentsGet: " + response.ErrorMessage, response.ErrorMessage);

            return (List<StudentBO>)ApiClient.Deserialize(response.Content, typeof(List<StudentBO>), response.Headers);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentBO</returns>
        public StudentBO ApiStudentGetStudentByIdGet(int? id)
        {

            var path = "/api/Student/GetStudentById";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            if (id != null) queryParams.Add("id", ApiClient.ParameterToString(id)); // query parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentGetStudentByIdGet: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiStudentGetStudentByIdGet: " + response.ErrorMessage, response.ErrorMessage);

            return (StudentBO)ApiClient.Deserialize(response.Content, typeof(StudentBO), response.Headers);
        }

    }
}
