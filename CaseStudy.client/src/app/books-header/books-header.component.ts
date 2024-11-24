import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookFormComponent } from '../book-form/book-form.component';

@Component({
  selector: 'books-header',
  standalone: true,
  imports: [BookFormComponent, CommonModule],
  templateUrl: './books-header.component.html',
  styleUrl: './books-header.component.css',
})
export class BooksHeaderComponent {
  isAdding: boolean = false;
  @Input() bookGenres!: String[];

  onToggle() {
    this.isAdding = !this.isAdding;
  }
}
