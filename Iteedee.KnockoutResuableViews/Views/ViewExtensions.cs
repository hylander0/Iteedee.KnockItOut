using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;


namespace Iteedee.KnockoutResuableViews.Views
{
    public static class ViewExtensions
    {
        public static IHtmlString PartialResource(this HtmlHelper HtmlHelper, Func<object, HelperResult> Template, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null) ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type]).Add(Template);
            else HtmlHelper.ViewContext.HttpContext.Items[Type] = new List<Func<object, HelperResult>>() { Template };


            return new HtmlString(String.Empty);
        }


        public static IHtmlString RenderPartialResources(this HtmlHelper HtmlHelper, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null)
            {
                List<Func<object, HelperResult>> Resources = (List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type];


                foreach (var Resource in Resources)
                {
                    if (Resource != null) HtmlHelper.ViewContext.Writer.Write(Resource(null));
                }
            }


            return new HtmlString(String.Empty);
        }
        public static IHtmlString RenderPartialKnockoutResource(this HtmlHelper HtmlHelper, string Action, string Controller, string jsonModel)
        {
            return HtmlHelper.RenderPartialKnockoutResourceWithScope(Action, Controller, jsonModel, null);
        }
        public static IHtmlString RenderPartialKnockoutResourceWithScope(this HtmlHelper HtmlHelper, string Action, string Controller, string jsonModel, string rootDomBindingElement)
        {
            Func<object, HelperResult> jsViewModelInit = (d =>
            {
                return new HelperResult(writer =>
                {
                    writer.Write(@"<script src='{0}Scripts/app/Views/{1}/{2}.ViewModel.js' type='text/javascript'></script>", 
                                            HtmlHelper.GetApplicationBaseUrl(), 
                                            Controller, 
                                            Action);
                });

            });

            Func<object, HelperResult> jsKnockOutInit = (d =>
            {
                return new HelperResult(writer =>
                {
                    dynamic rawModel = HtmlHelper.Raw(jsonModel);
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<script type='text/javascript'>");
                    sb.AppendLine("     $(function () {");
                    sb.AppendFormat("     var viewModelObj = APP.{0}.{1}ViewModel(ko.mapping.fromJS({2}));{3}", Controller, Action, rawModel, Environment.NewLine);
                    if (string.IsNullOrEmpty(rootDomBindingElement))
                        sb.AppendLine("     ko.applyBindings(viewModelObj);");
                    else
                        sb.AppendFormat("     ko.applyBindings(viewModelObj, document.getElementById('{0}'));{1}", rootDomBindingElement, Environment.NewLine);
                    sb.AppendLine("     });");
                    sb.AppendLine("</script>");
                    writer.Write(sb.ToString());
                });

            });

            if (HtmlHelper.ViewContext.HttpContext.Items["js"] == null)
            {
                HtmlHelper.ViewContext.HttpContext.Items["js"] = new List<Func<object, HelperResult>>();
            }

            ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items["js"]).Add(jsViewModelInit);
            ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items["js"]).Add(jsKnockOutInit);

            return new HtmlString(String.Empty);
        }

        public static string GetApplicationBaseUrl(this HtmlHelper HtmlHelper)
        {
            var hlr = new UrlHelper(HttpContext.Current.Request.RequestContext);
            return string.Format("{0}://{1}{2}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, hlr.Content("~"));
        }


    }
}