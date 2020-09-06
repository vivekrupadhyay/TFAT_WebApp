using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;

    
namespace Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Choose your language</summary>
        public static string language {
               get {
                   return resourceProvider.GetResource("language", CultureInfo.CurrentUICulture.Name) as string;
               }
            }
            
        /// <summary>We suggest the following:</summary>
        public static string suggest {
               get {
                   return resourceProvider.GetResource("suggest", CultureInfo.CurrentUICulture.Name) as string;
               }
            }

        }        
}
