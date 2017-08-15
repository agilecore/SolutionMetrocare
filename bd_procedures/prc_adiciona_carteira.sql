delimiter $$

drop procedure if exists sp_adiciona_carteira$$
 
create procedure sp_adiciona_carteira
(   
    in v_id_carteira     int          ,         
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

    if exists (select id_carteira from carteira where id_carteira = v_id_carteira) then

        update carteira          
           set id_carteira         = v_id_carteira         ,         
               id_plano            = v_id_plano            ,
               id_usuario          = v_id_usuario          ,
               id_plano_inativacao = v_id_plano_inativacao ,
               id_benef_depend     = v_id_benef_depend     ,
               dt_ativacao         = v_dt_ativacao         ,
               dt_inativacao       = v_dt_inativacao       ,
               marca_optica        = v_marca_optica        ,
               status              = v_status             
         where id_carteira         = id_carteira;         
         commit;

    else

        insert into carteira 
        (
            id_carteira           ,
            id_plano              ,
            id_usuario            ,
            id_plano_inativacao   ,
            id_benef_depend       ,
            dt_ativacao           ,
            dt_inativacao         ,
            marca_optica          ,
            status                
         )                    
        values               
        (     
            v_id_carteira         ,   
            v_id_plano            ,
            v_id_usuario          ,
            v_id_plano_inativacao ,
            v_id_benef_depend     ,
            v_dt_ativacao         ,
            v_dt_inativacao       ,
            v_marca_optica        ,
            v_status              
        );  
        commit;

    end if;

end$$

delimiter ; 