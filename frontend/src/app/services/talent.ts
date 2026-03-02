import { Injectable } from '@angular/core';
import { Observable, from } from 'rxjs';
import { TalentInfo } from '../Models/TalentInfo';

@Injectable({
  providedIn: 'root',
})
export class TalentService {
  private apiUrl = 'http://localhost:5207/api/TalentInfo';

  // 取得人才資料 (支援分頁與搜尋)
  getAllTalents(
    pageIndex: number,
    pageSize: number,
    searchText: string,
  ): Observable<{ items: TalentInfo[]; total: number }> {
    const url = `${this.apiUrl}?page=${pageIndex}&pageSize=${pageSize}&search=${encodeURIComponent(searchText)}`;

    return from(
      fetch(url).then((res) => {
        if (!res.ok) throw new Error('Network response was not ok');
        return res.json() as Promise<{ items: TalentInfo[]; total: number }>;
      }),
    );
  }

  // 依 ID 取得單一人才
  getTalentById(id: string): Observable<TalentInfo> {
    return from(
      fetch(`${this.apiUrl}/${id}`).then((res) => {
        if (!res.ok) throw new Error('Network response was not ok');
        return res.json() as Promise<TalentInfo>;
      }),
    );
  }

  // 新增人才
  addTalent(talent: TalentInfo): Observable<TalentInfo> {
    return from(
      fetch(this.apiUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(talent),
      }).then((res) => {
        if (!res.ok) throw new Error('Network response was not ok');
        return res.json() as Promise<TalentInfo>;
      }),
    );
  }

  // 更新人才
  updateTalent(id: string, talent: TalentInfo): Observable<TalentInfo> {
    return from(
      fetch(`${this.apiUrl}/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(talent),
      }).then((res) => {
        if (!res.ok) throw new Error('Network response was not ok');
        return res.json() as Promise<TalentInfo>;
      }),
    );
  }

  // 刪除人才
  deleteTalent(id: string): Observable<void> {
    return from(
      fetch(`${this.apiUrl}/${id}`, {
        method: 'DELETE',
      }).then((res) => {
        if (!res.ok) throw new Error('Network response was not ok');
        return;
      }),
    );
  }
}
