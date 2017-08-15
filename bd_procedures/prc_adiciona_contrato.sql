delimiter $$

drop procedure if exists sp_adiciona_contrato$$
 
create procedure sp_adiciona_contrato
(   
    in v_id_contrato     int          ,         
    in v_id_plano        int          ,  
    in v_id_usuario      int          ,  
    in v_nome            varchar(255) ,  
    in v_descricao       text         ,  
    in v_dt_cadastro     date         ,  
    in v_dt_ativacao     date         ,  
    in v_dt_desativacao  date         ,  
    in v_documento       varchar(255) ,  
    in v_status          char(1)       
)      
begin

    if exists (select id_contrato from contrato where id_contrato = v_id_contrato) then

        update contrato 
           set id_plano       = v_id_plano       , 
			   id_usuario     = v_id_usuario     ,
			   nome           = v_nome           ,
			   descricao      = v_descricao      ,
			   dt_cadastro    = v_dt_cadastro    ,
			   dt_ativacao    = v_dt_ativacao    ,
			   dt_desativacao = v_dt_desativacao ,
			   documento      = v_documento      ,
			   status         = v_status         
         where id_contrato    = v_id_contrato;
         commit;
		 
    else

        insert into contrato 
        (
            id_contrato       ,
            id_plano          ,
            id_usuario        ,
            nome              ,
            descricao         ,
            dt_cadastro       ,
            dt_ativacao       ,
            dt_desativacao    ,
            documento         ,
            status            
        )                    
        values               
        (     
            v_id_contrato     ,
            v_id_plano        ,
            v_id_usuario      ,
            v_nome            ,
            v_descricao       ,
            v_dt_cadastro     ,
            v_dt_ativacao     ,
            v_dt_desativacao  ,
            v_documento       ,
            v_status          
        );  
        commit;

    end if;

end$$ 

delimiter ;