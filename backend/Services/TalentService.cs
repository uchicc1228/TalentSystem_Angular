using TalentApi.Models;

namespace TalentApi.Services
{
    public class TalentService
    {
        private readonly List<TalentInfo> _talents = new();

        public TalentService()
        {
            // 初始化 100 筆假資料
            for (int i = 1; i <= 100; i++)
            {
                _talents.Add(new TalentInfo
                {
                    TalentID = $"T{i:D3}", // T001, T002, ...
                    TalentName = $"測試人才{i}",
                    Email = $"talent{i}@example.com",
                    Sex = i % 2 == 0, // 偶數男，奇數女
                    Phone = $"02-1234-{i:D4}",
                    MobilePhone = $"0912-345-{i:D3}",
                    WorkAreas = $"工作區域{i % 5}", // 模擬不同工作區域
                    Skills = $"技能{i % 10}",       // 模擬不同技能
                    Status = i % 3 == 0,           // 模擬不同狀態
                    CreationTime = DateTime.UtcNow.AddDays(-i),
                    LastModifiedAt = DateTime.UtcNow,
                    LastModifiedBy = $"Admin{i % 3}"
                });
            }
        }

        // 支援分頁 + 搜尋
        public (IEnumerable<TalentInfo> Items, int Total) GetAll(int pageIndex, int pageSize, string searchText)
        {
            // 先過濾搜尋條件
            var query = _talents.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(t =>
                    (t.TalentName != null && t.TalentName.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
                    (t.Email != null && t.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                );
            }

            var total = query.Count();

            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (items, total);
        }

        public TalentInfo? GetById(string id) => _talents.FirstOrDefault(t => t.TalentID == id);

        public void Add(TalentInfo talent) => _talents.Add(talent);

        public bool Update(string id, TalentInfo updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.TalentName = updated.TalentName;
            existing.Email = updated.Email;
            existing.Sex = updated.Sex;
            existing.Phone = updated.Phone;
            existing.MobilePhone = updated.MobilePhone;
            existing.WorkAreas = updated.WorkAreas;
            existing.Skills = updated.Skills;
            existing.Status = updated.Status;
            existing.LastModifiedAt = DateTime.UtcNow;
            existing.LastModifiedBy = updated.LastModifiedBy;
            return true;
        }

        public bool Delete(string id)
        {
            var existing = GetById(id);
            if (existing == null) return false;
            _talents.Remove(existing);
            return true;
        }
    }
}

