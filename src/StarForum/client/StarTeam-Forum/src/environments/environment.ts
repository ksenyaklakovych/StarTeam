// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
    production: false,
    baseURL:"https://localhost:44378/",
    externalLoginUrl: "api/Auth/ExternalLogin",
    externalSignOutUrl: "",
    getAllQuestionsUrl: "api/questions/questions",
    getQuestionByIdUrl: "api/questions/getById",
    createQuestionUrl: "api/questions/add",
    getQuestionsByTagUrl: "api/questions/getByTag",
    filterTagsUrl: "api/tags/filter",
    isQuestionFavouriteUrl: "api/questions/isFavourite",
    changeIsFavouriteUrl: "api/questions/changeIsFavourite",
    getFavouritesUrl: "api/questions/favourites"
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
