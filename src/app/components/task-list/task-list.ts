import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TaskService } from '../../services/task';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './task-list.html',
  styleUrls: ['./task-list.css']
})
export class TaskListComponent implements OnInit {

  tasks: any[] = [];

  constructor(private service: TaskService) {}

  ngOnInit() {
    this.loadTasks();   // ✅ loads automatically on page load
  }

  loadTasks() {
    this.service.getTasks().subscribe((res: any) => {
      this.tasks = res;
    });
  }

  deleteTask(id: number) {
    if (confirm('Delete this task?')) {
      this.service.deleteTask(id).subscribe(() => {
        this.loadTasks(); // refresh list
      });
    }
  }
}