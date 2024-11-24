import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../shared/models/Book';
import { BookFormComponent } from '../book-form/book-form.component';
import { EventService } from '../../shared/services/EventService';

@Component({
  selector: 'book-item',
  standalone: true,
  imports: [CommonModule, BookFormComponent],
  templateUrl: './book-item.component.html',
  styleUrl: './book-item.component.css',
})
export class BookItemComponent {
  @Input() book!: Book;
  @Input() bookGenres!: String[];
  isEditing: boolean = false;

  constructor(private events: EventService) {}

  onClickEditClose() {
    this.isEditing = !this.isEditing;
  }

  onDelete() {
    this.events.emit('deleteBook', this.book);
  }
}
