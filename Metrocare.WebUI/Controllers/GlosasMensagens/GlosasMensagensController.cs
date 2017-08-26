using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class GlosasMensagensController : Base                                 
    {                                                                               
        internal GlosasMensagens _GlosasMensagens { get; set; }                 
                                                                                    
        public GlosasMensagensController()                                        
        {                                                                           
            _GlosasMensagens = new GlosasMensagens();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionGlosasMensagens = _GlosasMensagens.GetAll().ToList(); 
            return View(collectionGlosasMensagens);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new GlosasMensagensDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(GlosasMensagensDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var GlosasMensagens = new GlosasMensagens();                    
                _GlosasMensagens.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

