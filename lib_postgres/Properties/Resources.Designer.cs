﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lib_postgres.Properties {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("lib_postgres.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap black_hole {
            get {
                object obj = ResourceManager.GetObject("black_hole", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap broken_base {
            get {
                object obj = ResourceManager.GetObject("broken_base", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap creation01 {
            get {
                object obj = ResourceManager.GetObject("creation01", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap happy_HDD {
            get {
                object obj = ResourceManager.GetObject("happy_HDD", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap img_bookshelf {
            get {
                object obj = ResourceManager.GetObject("img_bookshelf", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap img_good_DB {
            get {
                object obj = ResourceManager.GetObject("img_good_DB", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap img_HDD {
            get {
                object obj = ResourceManager.GetObject("img_HDD", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap img_noconnect {
            get {
                object obj = ResourceManager.GetObject("img_noconnect", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à --all tables here: 
        ///-- action
        ///-- art
        ///-- art_read
        ///-- art_to_read
        ///-- author_art
        ///-- book
        ///-- location
        ///-- possession	
        ///
        ///-- public.author_art
        ///
        ///ALTER TABLE IF EXISTS public.author_art
        ///	DROP CONSTRAINT author_art_art_fkey,
        ///    ADD CONSTRAINT author_art_art_fkey FOREIGN KEY (art)
        ///    REFERENCES public.art (id) MATCH SIMPLE
        ///    ON UPDATE NO ACTION
        ///    ON DELETE CASCADE;
        ///	
        ///ALTER TABLE IF EXISTS public.author_art
        ///    DROP CONSTRAINT author_art_author_fkey,
        ///	ADD CONSTRAINT author_art_author_fkey FORE [le reste de la chaîne a été tronqué]&quot;;.
        /// </summary>
        public static string Query_Set_On_Delete_Cascade {
            get {
                return ResourceManager.GetString("Query_Set_On_Delete_Cascade", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une ressource localisée de type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap wand {
            get {
                object obj = ResourceManager.GetObject("wand", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
