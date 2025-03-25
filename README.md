# Multi Agents AI tour 2025

## Introduction

This repository contains the code for the multi-agent demo used in the AI Tour 2025.

All demos are part of the same polyglot notebook and written in c#. The notebook is available in the `dotnet` with name [`sk-agents.dib`](dotnet/sk-agents.dib).

Before running any demo, copy the `settings-emtpy.json` file to a new `settings.json`. Set all the necessary parameters there.

## Demos

- Installation of required packages and setup of the configuration. [Set up](dotnet/sk-agents.dib#install-packages-and-read-configuration)
- [First agent](dotnet/sk-agents.dib#create-an-agent-based-on-the-most-simple-kernel) using Semantic Kernel
- [Semantic Kernel Agent with plugins](dotnet/sk-agents.dib#agent-with-a-vitamined-kernel)
- Multi-agents orchestation:
    - [Tour planner](dotnet/sk-agents.dib#tour-planner): An Agents group chat with sequential selection strategy and simple approval termination strategy.
    - [Hotel recepcionist service: a day plan ](dotnet/sk-agents.dib#hotel-recepcionist-service-a-day-plan): An Agents group chat with custom selection strategy and custom approval termination strategy.
    - [Hotel recepcionist service: a day plan + Foundry AI Agent Service](dotnet/sk-agents.dib#hotel-recepcionist-service-a-day-plan-foundry-ai-agent-service): An Agents group chat where two agents are defined in the AI Agent Service of AI Foundry. Same as previous scenario, there are custom selection strategy and custom approval termination strategy set.