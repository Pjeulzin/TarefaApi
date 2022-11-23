using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using TarefaApi.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using System.Collections;
using TarefaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace TarefaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaDbContext dbContext;

        public TarefaController(TarefaDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var reg = await dbContext.Tarefas.FirstOrDefaultAsync(m => m.Codigo == id);

            if (reg == null)
                return StatusCode(404, "Nenhuma Tarefa Encontrada");

            return Ok(reg);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await dbContext.Tarefas.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] AddTarefa tarefa)
        {
            try
            {
                await dbContext.Tarefas.AddRangeAsync(new Tarefa { Descricao = tarefa.Descricao, Status = "P" });
                await dbContext.SaveChangesAsync();

            } 
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

            return Ok(dbContext.Tarefas.Last());
        } 

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTarefa tarefa, int id)
        {
            var reg = await dbContext.Tarefas.FirstOrDefaultAsync(m => m.Codigo == id);
            
            try
            {    
                if (reg == null)
                    return StatusCode(404, "Nenhuma Tarefa Encontrada");

                if (tarefa.Status != "C" && tarefa.Status != "P")
                    return StatusCode(500, "Campo 'status' permite somente valores (P/C)");

                reg.Status = tarefa.Status;
                reg.Descricao = tarefa.Descricao;
                
                await dbContext.SaveChangesAsync();

            } 
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

            return Ok(reg);
        }

    }
}
