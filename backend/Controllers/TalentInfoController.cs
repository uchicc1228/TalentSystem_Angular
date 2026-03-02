using Microsoft.AspNetCore.Mvc;
using TalentApi.Helper;
using TalentApi.Models;
using TalentApi.Services;

namespace TalentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TalentInfoController : ControllerBase
    {
        private readonly TalentService _service;
        private readonly ILogger<TalentInfoController> _logger;

        public TalentInfoController(TalentService service, ILogger<TalentInfoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
        {
            var result = _service.GetAll(page, pageSize, search);
            return Ok(new { items = result.Items, total = result.Total });
        }

        [HttpGet("{id}")]
        public ActionResult<TalentInfo> GetById(string id)
        {
            LogHelper.Info(_logger, $"呼叫 GetById API, id={id}");
            var talent = _service.GetById(id);
            if (talent == null)
            {
                LogHelper.Warn(_logger, $"找不到 Talent, id={id}");
                return NotFound();
            }
            return Ok(talent);
        }

        [HttpPost]
        public IActionResult Add([FromBody] TalentInfo talent)
        {
            LogHelper.Info(_logger, $"新增 Talent, id={talent.TalentID}");
            _service.Add(talent);
            return CreatedAtAction(nameof(GetById), new { id = talent.TalentID }, talent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TalentInfo talent)
        {
            LogHelper.Info(_logger, $"更新 Talent, id={id}");
            var success = _service.Update(id, talent);
            if (!success)
            {
                LogHelper.Warn(_logger, $"更新失敗, id={id}");
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            LogHelper.Info(_logger, $"刪除 Talent, id={id}");
            var success = _service.Delete(id);
            if (!success)
            {
                LogHelper.Warn(_logger, $"刪除失敗, id={id}");
                return NotFound();
            }
            return NoContent();
        }
    }
}
