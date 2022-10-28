# BlazorWasmMixedwithServerPages
Prepared to support stackoverflow answer.  https://stackoverflow.com/questions/74230471/blazor-wasm-hosted-mixed-with-blazor-server-pages/74230472#74230472

I want to be able to mix and match pages in my app between Web Assembly (WASM) and Server to best suit the application. eg. for pages that need to be highly secure or protect IP, I want to use Server pages, for other pages that I would like to offload workload to the client for performance or other reasons, I'll use WASM.

My plan was to use a Blazor Web Assembly hosted project, with the WASM pages hosted from the Client project and Server pages hosted from the Server project.

However, it has proven to be more complex than I anticipated to implement this and I wasn't able to find a write-up of this scenario.

The closest I could get was a series of posts and articles like this one https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/multiple-hosted-webassembly around hosting multiple web-assembly projects. However, this only works for multiple WASM projects within a single solution. It does not explain how to host Blazor Server pages from the Server project.

The above Microsoft link states that:

"Optionally, the server project (MultipleBlazorApps.Server) can serve pages or views as a formal Razor Pages or MVC app."

I wanted to change this advice so that I could also serve Blazor Components from the Server project as well. The following answer describes how I got it to work. Please share any other comments / alternative methods if you have also tried to get this to work. (refer to SO link for answer.)
