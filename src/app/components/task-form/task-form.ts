import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { TaskService } from '../../services/task';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './task-form.html',
  styleUrls: ['./task-form.css']
})
export class TaskFormComponent {

  task: any = {
    title: '',
    description: '',
    isCompleted: false
  };

  constructor(private service: TaskService, private router: Router) {}

  save() {
    this.service.addTask(this.task).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}