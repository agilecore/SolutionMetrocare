using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class GrauParentescoController : Base                                 
    {                                                                               
        internal GrauParentesco _GrauParentesco { get; set; }                 
                                                                                    
        public GrauParentescoController()                                        
        {                                                                           
            _GrauParentesco = new GrauParentesco();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionGrauParentesco = _GrauParentesco.GetAll().ToList(); 
            return View(collectionGrauParentesco);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new GrauParentescoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(GrauParentescoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var GrauParentesco = new GrauParentesco();                    
                _GrauParentesco.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

