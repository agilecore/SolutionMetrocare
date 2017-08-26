using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class PlanoInativacaoController : Base                                 
    {                                                                               
        internal PlanoInativacao _PlanoInativacao { get; set; }                 
                                                                                    
        public PlanoInativacaoController()                                        
        {                                                                           
            _PlanoInativacao = new PlanoInativacao();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionPlanoInativacao = _PlanoInativacao.GetAll().ToList(); 
            return View(collectionPlanoInativacao);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new PlanoInativacaoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(PlanoInativacaoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var PlanoInativacao = new PlanoInativacao();                    
                _PlanoInativacao.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

