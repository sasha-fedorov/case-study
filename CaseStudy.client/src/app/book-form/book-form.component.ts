import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Book } from '../../shared/models/Book';
import { EventService } from '../../shared/services/EventService';

@Component({
  selector: 'book-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './book-form.component.html',
  styleUrl: './book-form.component.css',
})
export class BookFormComponent implements OnInit {
  @Input() book: Book = new Book();
  @Input() bookGenres: String[] = ['Other'];

  bookForm: FormGroup = new FormBuilder().group({});

  constructor(private events: EventService) {}

  ngOnInit(): void {
    this.bookForm = new FormBuilder().group({
      title: this.book.Title,
      author: this.book.Author,
      publishYear: this.book.PublishYear,
      genre: [this.book.Genre],
    });
  }

  onSubmit() {
    this.book.Title = this.bookForm.value.title ?? '';
    this.book.Author = this.bookForm.value.author ?? '';
    this.book.PublishYear = this.bookForm.value.publishYear ?? 0;
    this.book.Genre = this.bookForm.value.genre ?? this.bookGenres[0];

    if (this.book.Id) {
      this.events.emit('updateBook', this.book);
    } else {
      this.events.emit('addBook', this.book);
    }
  }
}
