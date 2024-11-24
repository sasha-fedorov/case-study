import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Collection } from '../../shared/models/Collection';
import { EventService } from '../../shared/services/EventService';

@Component({
  selector: 'collection-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './collection-form.component.html',
  styleUrl: './collection-form.component.css',
})
export class CollectionFormComponent implements OnInit {
  @Input() collection: Collection = new Collection();

  collectionForm: FormGroup = new FormBuilder().group({});

  constructor(private events: EventService) {}

  ngOnInit(): void {
    this.collectionForm = new FormBuilder().group({
      name: this.collection.Name,
    });
  }

  onSubmit() {
    this.collection.Name = this.collectionForm.value.name ?? '';

    if (this.collection.Id) {
      this.events.emit('updateCollection', this.collection);
    } else {
      this.events.emit('addCollection', this.collection);
    }
  }
}
