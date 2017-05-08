using gmcscoServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Transactions;

namespace gmcscoServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        private GmContext _obj;
        public Service()
        {
            this._obj = new GmContext();
        }
        public ReturnValues Consultant(ContactMessage obj)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    reposSendMail o = new reposSendMail();
                    string dd = o.contentBody(obj).Replace("\r", string.Empty).Replace("\n", string.Empty);
                    obj.CreatedDate = DateTime.Now;
                    _obj.ContactMessage.Add(obj);
                    _obj.SaveChanges();
                    ReturnValues ReturnObj = new ReturnValues
                    {

                        Success = "Message Successfully",
                    };
                    trans.Complete();
                    return ReturnObj;
                }
                catch (Exception ex)
                {
                    trans.Dispose();

                    ReturnValues objex = new ReturnValues
                    {
                        Failure = ex.Message,
                        Source = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.AbsoluteUri,
                    };
                    throw new WebFaultException<ReturnValues>(objex, System.Net.HttpStatusCode.InternalServerError);
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }

        public ReturnValues SaveSubscription(string Email)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    ReturnValues ReturnObj = null;
                    if (!(_obj.Subscribe.Where(z => z.Email == Email).Any()))
                    {
                        Subscribe objsubs = new Subscribe { Email = Email, CreatedDate = DateTime.Now, IpAddress=GetUserIPAddress() };
                        _obj.Subscribe.Add(objsubs);
                        _obj.SaveChanges();

                        ReturnObj = new ReturnValues
                        {
                            Success = "Success",
                        };
                    }
                    else
                    {
                        ReturnObj = new ReturnValues
                        {
                            Success = "Exist",
                        };

                    }

                    trans.Complete();
                    return ReturnObj;
                }
                catch (Exception ex)
                {
                    trans.Dispose();

                    ReturnValues objex = new ReturnValues
                    {
                        Failure = ex.Message,
                        Source = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.AbsoluteUri,
                    };
                    throw new WebFaultException<ReturnValues>(objex, System.Net.HttpStatusCode.InternalServerError);
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }


        public List<string> getSubscription()
        {
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    return _obj.Set<Subscribe>().Select(z=>z.Email).ToList();
                }
                catch (Exception ex)
                {
                    trans.Dispose();

                    ReturnValues objex = new ReturnValues
                    {
                        Failure = ex.Message,
                        Source = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.AbsoluteUri,
                    };
                    throw new WebFaultException<ReturnValues>(objex, System.Net.HttpStatusCode.InternalServerError);
                }
                finally
                {
                    trans.Dispose();
                }
            }
        }


        /// <summary>
        /// Get current user ip address.
        /// </summary>
        /// <returns>The IP Address</returns>
        public  string GetUserIPAddress()
        {
            var context = System.Web.HttpContext.Current;
            string ip = String.Empty;

            if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
                ip = context.Request.UserHostAddress;

            if (ip == "::1")
                ip = "127.0.0.1";

            return ip;
        }
    }
}
