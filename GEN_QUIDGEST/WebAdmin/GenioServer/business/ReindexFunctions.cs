using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- SQBCLUBE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAclube.FldCodclube)
                .From(CSGenioAclube.AreaCLUBE)
                .Where(CriteriaSet.And().In(CSGenioAclube.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAclube model = new CSGenioAclube(user);
                model.ValCodclube = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBJOGADOR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAjogador.FldCodjogador)
                .From(CSGenioAjogador.AreaJOGADOR)
                .Where(CriteriaSet.And().In(CSGenioAjogador.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAjogador model = new CSGenioAjogador(user);
                model.ValCodjogador = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBJOGO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAjogo.FldCodjogo)
                .From(CSGenioAjogo.AreaJOGO)
                .Where(CriteriaSet.And().In(CSGenioAjogo.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAjogo model = new CSGenioAjogo(user);
                model.ValCodjogo = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBTREINADOR --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtreinador.FldCodtreinador)
                .From(CSGenioAtreinador.AreaTREINADOR)
                .Where(CriteriaSet.And().In(CSGenioAtreinador.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtreinador model = new CSGenioAtreinador(user);
                model.ValCodtreinador = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBCONVOCATORIA --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAconvocatoria.FldCodconvocatoria)
                .From(CSGenioAconvocatoria.AreaCONVOCATORIA)
                .Where(CriteriaSet.And().In(CSGenioAconvocatoria.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAconvocatoria model = new CSGenioAconvocatoria(user);
                model.ValCodconvocatoria = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBTREINO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAtreino.FldCodtreino)
                .From(CSGenioAtreino.AreaTREINO)
                .Where(CriteriaSet.And().In(CSGenioAtreino.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAtreino model = new CSGenioAtreino(user);
                model.ValCodtreino = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBEXERCICIO --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAexercicio.FldCodexercicio)
                .From(CSGenioAexercicio.AreaEXERCICIO)
                .Where(CriteriaSet.And().In(CSGenioAexercicio.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAexercicio model = new CSGenioAexercicio(user);
                model.ValCodexercicio = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- SQBPRESENCA --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApresenca.FldCodpresenca)
                .From(CSGenioApresenca.AreaPRESENCA)
                .Where(CriteriaSet.And().In(CSGenioApresenca.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApresenca model = new CSGenioApresenca(user);
                model.ValCodpresenca = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- SQBmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBmem")
                .Where(CriteriaSet.And().In("SQBmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBcfg")
                .Where(CriteriaSet.And().In("SQBcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBlstusr")
                .Where(CriteriaSet.And().In("SQBlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBlstcol")
                .Where(CriteriaSet.And().In("SQBlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBlstren")
                .Where(CriteriaSet.And().In("SQBlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBusrwid")
                .Where(CriteriaSet.And().In("SQBusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBusrcfg")
                .Where(CriteriaSet.And().In("SQBusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBusrset")
                .Where(CriteriaSet.And().In("SQBusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBwkfact")
                .Where(CriteriaSet.And().In("SQBwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBwkfcon")
                .Where(CriteriaSet.And().In("SQBwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBwkflig")
                .Where(CriteriaSet.And().In("SQBwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBwkflow")
                .Where(CriteriaSet.And().In("SQBwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBnotifi")
                .Where(CriteriaSet.And().In("SQBnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBprmfrm")
                .Where(CriteriaSet.And().In("SQBprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBscrcrd")
                .Where(CriteriaSet.And().In("SQBscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBpostit")
                .Where(CriteriaSet.And().In("SQBpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBalerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBalerta")
                .Where(CriteriaSet.And().In("SQBalerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBaltent --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBaltent")
                .Where(CriteriaSet.And().In("SQBaltent", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBtalert")
                .Where(CriteriaSet.And().In("SQBtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBdelega")
                .Where(CriteriaSet.And().In("SQBdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBTABDINAMIC")
                .Where(CriteriaSet.And().In("SQBTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBaltran --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBaltran")
                .Where(CriteriaSet.And().In("SQBaltran", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBworkflowtask")
                .Where(CriteriaSet.And().In("SQBworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- SQBworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("SQBworkflowprocess")
                .Where(CriteriaSet.And().In("SQBworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}