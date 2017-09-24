using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditReport.Data.PersonalInformation
{
    public enum ModalSize
    {
        Small,
        Large,
        Medium
    }
    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
    public enum Responsability
    {
        Joint = 1,
        Individual = 2,

    }

    public enum PaymentHistoryStatus
    {
        Ok = 1,
        Default=2,

    }
    public enum TransactionStatus
    {
        Opend=1,
        Close=2,
        Late = 3,
        Legal = 3,
    }
    public enum TransactionType
    {
        PrestamosHipotecario = 1,
        PrestamosConsumo = 2,
        TarjetaDeCreditos = 3,
        Agua = 4,
        Luz = 5,
        Telecomunicaciones = 6,
        CreditLine = 7,
        CourtHouse = 8,
        PrestamosVehiculo = 8,


    }
    public enum CivilStatus
    {
        Single = 1,
        Married = 2,

    }
    public enum CompanyRelationShip
    {
        Empleado=1,
        Deudor=2,

    }
    public enum PersonRelationShip
    {
        Mismo = 1,
        Madre = 2,
        Padres = 3,
        Hermano = 4,
        Hijo = 5,
        Garante = 6,
        CoAplicante = 7,

    }
    public enum Gender
    {
        Masculino = 1,
        Femenino = 2,
        NA = 3,
    }
    public enum ContactType
    {
        Telefono = 1,
        Email= 2,
        Web = 3,
    }

    public enum ContactLocationTypes
    {
        Celular = 1,
        Residencia = 2,
        Trabajo = 3,
        Otros = 4,
    }

    public enum InquiryType
    {
        PorfolioRevision = 1,
        CreditApplication = 2,
        Other = 3, 
    }
    
}
