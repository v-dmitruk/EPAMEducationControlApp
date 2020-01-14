import { Teacher } from './teacher.model';

export class Question {
    QuestionID : number;
    Creator : Teacher;
    CreationDate : Date;
    QuestionBody : string;
    Answer1 : string;
    Answer2 : string;
    Answer3 : string;
    Answer4 : string;
    RightAnswer : number;
    Category : string;
}
