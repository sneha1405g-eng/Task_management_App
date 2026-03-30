import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Task } from '../models/task';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = 'https://localhost:44303/api/tasks'; // YOUR API URL

  constructor(private http: HttpClient) {}

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.apiUrl);
  }

  getTask(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.apiUrl}/${id}`);
  }

  addTask(task: Task) {
    return this.http.post(this.apiUrl, task);
  }

  updateTask(task: Task) {
    return this.http.put(`${this.apiUrl}/${task.id}`, task);
  }

  deleteTask(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}