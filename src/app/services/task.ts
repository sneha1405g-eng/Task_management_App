import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = 'https://localhost:44303/api/tasks';

  constructor(private http: HttpClient) {}

  getTasks() {
    return this.http.get(this.apiUrl);
  }

  getTask(id: number) {
    return this.http.get(`${this.apiUrl}/${id}`);
  }
  
  deleteTask(id: number) {
  return this.http.delete(`${this.apiUrl}/${id}`);
}
  addTask(task: any) {
    return this.http.post(this.apiUrl, task);
  }
}