using System;                                                                       
using System.Collections.Generic;								                      
using System.Linq;                                                                  
using System.Web;                                                                   
using System.Web.Mvc;                                                               
using Metrocare.Common;                                                   
using Metrocare.Domain;                                                   
                                                                                    
namespace Metrocare.WebUI.Controllers                                     
{                                                                                   
    public class TipoInternacaoController : Base                                 
    {                                                                               
        internal TipoInternacao _TipoInternacao { get; set; }                 
                                                                                    
        public TipoInternacaoController()                                        
        {                                                                           
            _TipoInternacao = new TipoInternacao();                           
        }                                                                           
                                                                                    
        public ActionResult List()                                                  
        {                                                                           
            var collectionTipoInternacao = _TipoInternacao.GetAll().ToList(); 
            return View(collectionTipoInternacao);                               
        }                                                                           
                                                                                    
        public ActionResult Create()                                                
        {                                                                           
            return View(new TipoInternacaoDto());                                
        }                                                                           
                                                                                    
        [HttpPost]                                                                  
        public ActionResult Save(TipoInternacaoDto model)                        
        {                                                                           
            if (ModelState.IsValid)                                                 
            {                                                                       
                var TipoInternacao = new TipoInternacao();                    
                _TipoInternacao.Save(model);                                     
                return RedirectToAction("List");                                  
            }                                                                       
            else                                                                    
            {                                                                       
                return RedirectToAction("Create", model);                         
            }                                                                       
        }                                                                           
    }                                                                               
}                                                                                   

