using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class CredenciadoEnderecoController : Base                                 
    {                                                                               
        internal CredenciadoEndereco _CredenciadoEndereco { get; set; }                 
                                                                                    
        public CredenciadoEnderecoController()                                        
        {                                                                           
            _CredenciadoEndereco = new CredenciadoEndereco();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionCredenciadoEndereco = _CredenciadoEndereco.GetAll().ToList(); 
            return View(collectionCredenciadoEndereco);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new CredenciadoEnderecoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(CredenciadoEnderecoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var CredenciadoEndereco = new CredenciadoEndereco();                    
                _CredenciadoEndereco.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

