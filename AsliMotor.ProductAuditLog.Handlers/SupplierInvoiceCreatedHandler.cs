﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using AsliMotor.SI.Events;
using BonaStoco.Inf.Reporting;
using AsliMotor.AuditLog.Models;

namespace AsliMotor.AuditLog.Handlers
{
    public class SupplierInvoiceCreatedHandler : IMessageHandler<SupplierInvoiceCreated>
    {
        public IReportingRepository ReportingRepository { get; set; }
        public void Handle(SupplierInvoiceCreated message)
        {
            ReportingRepository.Save<SupplierInvoiceLog>(new SupplierInvoiceLog()
            {
                id = Guid.NewGuid(),
                Action = (int)Events.Created,
                BranchId = message.Payload.BranchId,
                Datetime = message.DateTime,
                HargaBeli = message.Payload.HargaBeli,
                Charge = message.Payload.Charge,
                Merk = message.Payload.Merk,
                NoBpkb = message.Payload.NoBpkb,
                NoMesin = message.Payload.NoMesin,
                NoPolisi = message.Payload.NoPolisi,
                NoRangka = message.Payload.NoRangka,
                Note = message.Payload.Note,
                NoTelp = message.Payload.NoTelp,
                ProductId = message.Payload.ProductId,
                SupplierBillingAddress = message.Payload.SupplierBillingAddress,
                SupplierInvoiceDate = message.Payload.SupplierInvoiceDate,
                SupplierInvoiceId = message.Payload.id,
                SupplierInvoiceNo = message.Payload.SupplierInvoiceNo,
                SupplierName = message.Payload.SupplierName,
                Tahun = message.Payload.Tahun,
                TransactionDate = message.Payload.TransactionDate,
                Type = message.Payload.Type,
                Username = message.UserName,
                Warna = message.Payload.Warna,
                BeforeCharge = message.Payload.Charge,
                BeforeHargaBeli = message.Payload.HargaBeli
            });
        }
    }
}
