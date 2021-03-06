import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AudioComponent }   from './question/audio/audio.component';
import { AnnouncementComponent }   from './question/announcement/announcement.component';
import { ImageComponent }   from './question/image/image.component';
import { VideoComponent }   from './question/video/video.component';
import { TextComponent }   from './question/text/text.component';
import { TextViewComponent }   from './question/text/view/view.component';
import { AnswerComponent }   from './answer/answer/answer.component';
import { HomeComponent } from './home/home.component';
import { QuestionsComponent } from './settings/questions/questions.component';
import { CreateComponentQuestion } from './settings/questions/create/create.component';
import { QuestionnaireComponent } from './settings/questionnaire/questionnaire.component';
import { CreateComponentQuestionnaire } from './settings/questionnaire/create/create.component';
import { EditComponentQuestion } from './settings/questions/edit/edit.component';
import { SessionsComponent } from './settings/sessions/sessions.component';
import { AnswersComponent } from './settings/answers/answers.component';
import { CreateComponentAnswers } from './settings/answers/create/create.component';
import { EditComponentAnswers } from './settings/answers/edit/edit.component';
import { GameFlowComponent } from './game-flow/game-flow.component';
import { ConnectComponent } from './home/connect/connect.component';
import { ViewquestionnaireComponent } from './questionnaire/viewquestionnaire/viewquestionnaire.component';


const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'question', component: QuestionsComponent},
  { path: 'question/edit', component: EditComponentQuestion },
  { path: 'question/view', component: TextViewComponent },
  { path: 'question/create', component: CreateComponentQuestion },
  { path: 'answer/view', component: AnswerComponent },
  { path: 'answer/edit', component: AnswerComponent },
  { path: 'questionnaire', component: ViewquestionnaireComponent },
  { path: 'questionnaire/create', component: CreateComponentQuestionnaire },
  { path: 'questionnaire/view', component: ViewquestionnaireComponent },
  { path: 'questionnaire/edit', component: QuestionnaireComponent },
  { path: 'session', component: SessionsComponent},
  { path: 'answer', component: AnswersComponent},
  { path: 'answer/create', component: CreateComponentAnswers},
  { path: 'answer/edit', component: EditComponentAnswers},
  { path: 'game', component: GameFlowComponent},
  { path: 'game/:id', component: GameFlowComponent },
  { path: 'connect', component: ConnectComponent},


  
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
