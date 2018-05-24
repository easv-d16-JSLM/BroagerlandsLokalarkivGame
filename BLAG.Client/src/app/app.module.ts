import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TextComponent } from './question/text/text.component';
import { AnnouncementComponent } from './question/announcement/announcement.component';
import { ImageComponent } from './question/image/image.component';
import { VideoComponent } from './question/video/video.component';
import { AudioComponent } from './question/audio/audio.component';
import { TextViewComponent } from './question/text/view/view.component';
import { ImageViewComponent } from './question/image/view/view.component';
import { VideoViewComponent } from './question/video/view/view.component';

@NgModule({
  declarations: [
    AppComponent,
    TextComponent,
    AnnouncementComponent,
    ImageComponent,
    VideoComponent,
    AudioComponent,
    TextViewComponent,
    ImageViewComponent,
    VideoViewComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
