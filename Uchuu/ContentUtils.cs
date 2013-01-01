using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hakase.Uchuu
{
    public class ContentUtils
    {
        public static string ResolveContentPath(string contentSubPath)
        {
            string resolvedContentPath = String.Empty;
            //contentSubPath = contentSubPath.Replace('\\', '/').Replace("//", "/");

            if (!String.IsNullOrEmpty(contentSubPath) && !String.IsNullOrWhiteSpace(contentSubPath))
            {
                //
                // Get the correct file path
                //
                string contentPath = Properties.Settings.Default.ContentPath;

                if (!contentSubPath.StartsWith(contentPath))
                {
                    contentSubPath = contentPath + contentSubPath;
                }

                resolvedContentPath = contentSubPath;
            }

            return resolvedContentPath;
        }
    }
}
