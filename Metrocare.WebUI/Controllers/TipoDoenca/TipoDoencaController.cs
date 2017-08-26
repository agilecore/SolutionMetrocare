using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TipoDoencaController : Base                                 
    {                                                                               
        internal TipoDoenca _TipoDoenca { get; set; }                 
                                                                                    
        public TipoDoencaController()                                        
        {                                                                           
            _TipoDoenca = new TipoDoenca();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTipoDoenca = _TipoDoenca.GetAll().ToList(); 
            return View(collectionTipoDoenca);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TipoDoencaDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TipoDoencaDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TipoDoenca = new TipoDoenca();                    
                _TipoDoenca.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

