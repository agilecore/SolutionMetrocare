delimiter $$

drop procedure if exists sp_adiciona_plano$$
 
create procedure sp_adiciona_plano
(   
    in v_id_plano            int          ,                 
    in v_id_plano_categoria  int          ,        
    in v_id_usuario          int          ,        
    in v_plano_inativacao    int          ,        
    in v_nome                varchar(255) ,        
    in v_registro_ans        varchar(255) ,        
    in v_dt_cadastro         date         ,        
    in v_dt_ativacao         date         ,        
    in v_dt_desativacao      date         ,        
    in v_idade_minima        int          ,        
    in v_idade_maxima        int          ,        
    in v_permite_dependentes char(1)      
)
begin

    if exists (select id_plano from plano where id_plano = v_id_plano) then

        update plano 
           set nome         = v_nome        ,                  
               cpf          = v_cpf         ,                
               cnpj         = v_cnpj        ,                
               email        = v_email       ,                
               logradouro   = v_logradouro  ,                
               complemento  = v_complemento ,                
               numero       = v_numero      ,                
               cep          = v_cep         ,                
               bairro       = v_bairro      ,                
               cidade       = v_cidade      ,                
               uf           = v_uf          ,                
               telefone     = v_telefone    ,                
               celular      = v_celular     ,                
               contato      = v_contato     ,                
               dt_cadastro  = v_dt_cadastro ,                
               longitude    = v_longitude   ,                
               latitude     = v_latitude    ,                
               ibge         = v_ibge        
         where id_plano     = v_id_plano;
         commit;

    else

        insert into plano 
        (
            id_plano              ,
            id_plano_categoria    ,
            id_usuario            ,
            plano_inativacao      ,
            nome                  ,
            registro_ans          ,
            dt_cadastro           ,
            dt_ativacao           ,
            dt_desativacao        ,
            idade_minima          ,
            idade_maxima          ,
            permite_dependentes  
        )                    
        values               
        (     
            v_id_plano            ,  
            v_id_plano_categoria  ,
            v_id_usuario          ,
            v_plano_inativacao    ,
            v_nome                ,
            v_registro_ans        ,
            v_dt_cadastro         ,
            v_dt_ativacao         ,
            v_dt_desativacao      ,
            v_idade_minima        ,
            v_idade_maxima        ,
            v_permite_dependentes 
        );  
        commit;

    end if;

end$$ 

delimiter ;