#!/usr/bin/env node 
 
import mjml2html from 'mjml';
 
var mjmlContentArgIndex = process.argv.indexOf("-c"); 
var helpArgIndex = process.argv.indexOf("-h"); 
 
if(mjmlContentArgIndex !== -1) 
{ 
   let content = process.argv[mjmlContentArgIndex + 1];
 
  if((typeof content) !== "string") 
    throw 'Content (-c) parameter must be a string' ;
 
  console.log(mjml2html(content).html) 
} 
 
else if(helpArgIndex !== -1) 
{ 
  console.log('help page'); 
} 
 
else 
{ 
  throw 'No content provided'; 
} 