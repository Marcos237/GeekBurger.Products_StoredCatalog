﻿using System;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.StoreCatalog.Contract;
using GeekBurger.StoreCatalog.Core.Interfaces;

namespace GeekBurger.StoreCatalog.Controllers
{

    public class StoreCatalogController : Controller
    {
        private IStoreCatalogCore _storeCatalogCore;
        public StoreCatalogController(IStoreCatalogCore storeCatalogCore)
        {
            _storeCatalogCore = storeCatalogCore;
        }
        [HttpGet("statusServer/")]
        public IActionResult GetStatusServer()
        {
            var result = new OperationResult<bool>();

            try
            {
                result.Data = _storeCatalogCore.StatusServers();
                result.Success = true;

                if (result.Data)
                    return Ok(result);
                else
                {
                    result.Message = "Services not available";
                    return StatusCode(503, result);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                return StatusCode(500, result);
            }
        }
    }
}