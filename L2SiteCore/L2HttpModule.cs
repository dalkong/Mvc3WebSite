using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Diagnostics;
namespace L2SiteCore
{
    public class L2HttpModule : IHttpModule
    {
        readonly string HttpContextItemsKey = "key_ABCDED";
        #region IHttpModule 멤버

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication ctx)
        {
            ctx.PreRequestHandlerExecute += new EventHandler(ctx_PreRequestHandlerExecute);
            ctx.PostRequestHandlerExecute += new EventHandler(ctx_PostRequestHandlerExecute);
        }

        void ctx_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpContext httpContext = ((HttpApplication)sender).Context;
            Stopwatch timer = (Stopwatch)httpContext.Items[HttpContextItemsKey];
            timer.Stop();

            if (HttpContext.Current.Items.Contains("NoDebug"))
            {
                return;
            }

            //HTML응답에만 실행 시간 정보를 출력한다.
            if (httpContext.Response.ContentType == "text/html")
            {
                double seconds = (double)timer.ElapsedTicks / Stopwatch.Frequency;
                string log = string.Format("<b>[실행 소요 시간]<br/> {0:F4} sec ({1:F0} req/sec)</b>", seconds, 1 / seconds);
                httpContext.Response.Write("<hr/>" + log);
                Trace.WriteLine(log);
            }
        }

        void ctx_PreRequestHandlerExecute(object sender, EventArgs g)
        {
            HttpContext httpContext = ((HttpApplication)sender).Context;
            Stopwatch timer = new Stopwatch();
            httpContext.Items[HttpContextItemsKey] = timer;
            timer.Start();
        }

        #endregion

        
    }
}
