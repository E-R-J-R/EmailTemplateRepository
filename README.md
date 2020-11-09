# Overview

Thank you for your interest in joining the Information Technology team at eComEngine, a leading SaaS provider that makes Amazon sellers more effective in running their businesses. As a SaaS company, our products are the heart of how we serve our customers, which makes software development a critical element of our collective success. As part of a Lean software development team, you'll work hand in hand with your colleagues to design, develop, test, deploy, and support your products. We're big believers that those doing the work are in the best position to decide how to accomplish the work and that requires a meaningful commitment to continuous growth and improvement, craftsmanship, innovation, and collaboration. 

This repository forms the basis for your coding submission as part of our interview process. Below you will find the basic outline of the problem with the features for you to develop and some notes on the technology to use. There is no right or wrong solution! Instead, the purpose of this exercise is to give us insight into how you approach designing a solution, provide insight into your personal development process, and to better inform the conversations you'll have with us during the process.  We respect the time investment it takes to apply for any position and further, to complete a submission such as this. As such, we generally think an hour or two is enough time to spend on this exercise though ultimately, it's up to you. We do recommend treating the submission like you would any other production change and include the aspects or elements you think are relevant to give us a clear picture of who you are as a software developer. 

---

## Your Submission

The submission you're going to deliver is the beginnings of an application to manage email templates. We'd like you to do the following:

1. Create a client-side application in the framework of your choice. We use Angular here so that would be our preference, but it's fine to use any similar framework you know well, such as React, Vue, etc.  This application should support the following features:

* Display a paged list of email templates (10 per page) with the email template elements Email Label, From Address, and Date Updated displayed.
* Allow sorting of the templates based on 1 or more of the visible email template elements
* Provide a way to show the Email Label of all nested Versions of an email template
* Support searching for email templates by partial Email Label text or partial From Address 

2. Create a .NET Web Api that will deliver the desired data (as JSON) to your client-side application. A set of email templates are provided (see "What's Included" below) as a representative test sample, but you should assume the real number of templates could run into the hundreds or even thousands. 

There is no particular need to account for the concept of users or to secure the the application as part of this exercise. 

---

## What's Included in this Repository

This repository contains working code (including some unit tests) for a basic repository class on top of an XML file that contains some email templates. The repository implementation is intended to stand in for your more typical database-facing repository. You're encouraged to incorporate this class into your solution as you see fit to save you some time and effort. Using it is not required and while modifying it isn't intended to be necessary, feel free to do so if inclined.  

---

## Getting Started

To get started on your submission:

1. Clone this repository
2. Create a new branch to hold your changes. Prefix the branch with "submission/" and then use any name you'd like. For example, "submission/12oct2020", "submission/john-doe", "submission/my-submission" are all perfectly acceptable branch names.  Your branches will never be seen by anyone other than eComEngine staff. 
3. Make all your changes on your branch.  These changes would include the addition of any new projects or external packages if necessary along with all your code to provide the requested features. 

---

## Submitting

To submit your solution to us, we'd suggest one of the two means below. 

1. Zip up your local repository (with all your committed changes) and place it onto Google Drive or similar cloud storage and email a link to access it to your HR recruiter. 
2. Send us a pull request through BitBucket. This may require you to create a BitBucket login prior to sending us the PR. 

We're open to other means that work best for you if different than the above - please work with your HR recruiter toward any other option. 

Again, we respect the time you've spent preparing this submission and we thank you for your interest in eComEngine!

