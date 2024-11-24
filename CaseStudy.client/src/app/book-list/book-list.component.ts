import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Book } from '../../shared/models/Book';
import { BookItemComponent } from '../book-item/book-item.component';

@Component({
  selector: 'book-list',
  standalone: true,
  imports: [BookItemComponent, CommonModule],
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css',
})
export class BookListComponent {
  @Input() books: Book[] = [];
  @Input() bookGenres!: String[];
}
