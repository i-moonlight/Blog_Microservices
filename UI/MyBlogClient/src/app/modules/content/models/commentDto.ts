import { User } from "src/app/core/models/user";

export class CommentDto {
    contentId!: string;
    text!: string;
    user!:User;
}