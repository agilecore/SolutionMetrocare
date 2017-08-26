using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class UsuarioController : Base                                 
    {                                                                               
        internal Usuario _Usuario { get; set; }                 
                                                                                    
        public UsuarioController()                                        
        {                                                                           
            _Usuario = new Usuario();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionUsuario = _Usuario.GetAll().ToList(); 
            return View(collectionUsuario);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new UsuarioDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(UsuarioDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var Usuario = new Usuario();                    
                _Usuario.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

