using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TipoGuiaController : Base                                 
    {                                                                               
        internal TipoGuia _TipoGuia { get; set; }                 
                                                                                    
        public TipoGuiaController()                                        
        {                                                                           
            _TipoGuia = new TipoGuia();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTipoGuia = _TipoGuia.GetAll().ToList(); 
            return View(collectionTipoGuia);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TipoGuiaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TipoGuiaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TipoGuia = new TipoGuia();                    
                _TipoGuia.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

