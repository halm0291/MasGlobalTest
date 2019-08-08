export class Token {
    
    static mapFromResponse(data: any): Token {
        return new Token(
            data.access_token,
            data.token_type,
            data.expires_in
        );
    }

    constructor(
        public access_token: string,
        public token_type: string,
        public expires_in: number,
    ) { }
}
