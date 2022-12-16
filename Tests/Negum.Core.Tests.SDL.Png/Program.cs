using System;
using System.IO;
using System.Linq;
using Negum.Core.Containers;
using Negum.Core.Models.Sprites.Png;
using Negum.Core.Readers.Sff.V2;
using static SDL2.SDL;

namespace Negum.Core.Tests.SDL.Png;

class Program
{
    static void Main(string[] args)
    {
        // const string samplePngPath = "/Users/kdobrzynski/Downloads/control3-60x10-256-noI-noT-noD.png";
        // const string samplePngPath = "/Users/kdobrzynski/Downloads/Rgb8.png";
        const string samplePngPath = "/Users/kdobrzynski/Downloads/Rgba32.png";

        var rawBytes = File.ReadAllBytes(samplePngPath);

        var reader = NegumContainer.Resolve<ISffPngReader>();

        var context = new SffPngReaderContext
        {
            PngFormat = 8,
            RawImage = rawBytes
        };

        var imageBytes = reader.ReadAsync(context).Result;
        var parsedImageBytes = imageBytes.ToArray();
            
        const int width = 374;
        const int height = 800; 

        // SDL stuff

        SDL_Init(SDL_INIT_EVERYTHING);

        var windowPtr = SDL_CreateWindow(
            "PngReader Test",
            SDL_WINDOWPOS_CENTERED,
            SDL_WINDOWPOS_CENTERED,
            1020,
            800,
            SDL_WindowFlags.SDL_WINDOW_SHOWN |
            SDL_WindowFlags.SDL_WINDOW_OPENGL |
            SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

        var rendererPtr = SDL_CreateRenderer(windowPtr, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

        SDL_Event e;
        var quit = false;

        while (!quit)
        {
            // Handle events on queue
            while (SDL_PollEvent(out e) != 0)
            {
                switch (e.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        quit = true;
                        break;
                    case SDL_EventType.SDL_KEYDOWN:
                        break;
                }
            }

            // Clear screen
            SDL_SetRenderDrawColor(rendererPtr, 255, 255, 255, 255);
            SDL_RenderClear(rendererPtr);

            // Render textures / sprites to screen
            unsafe
            {
                fixed (void* p = &parsedImageBytes[0])
                {
                    var texturePtr = SDL_CreateTexture(rendererPtr, SDL_PIXELFORMAT_ABGR8888,
                        (int) SDL_TextureAccess.SDL_TEXTUREACCESS_STATIC, width, height);

                    // var rect = new SDL_Rect
                    // {
                    //     w = width,
                    //     h = height,
                    //     x = 0,
                    //     y = 0
                    // };

                    SDL_SetRenderTarget(rendererPtr, texturePtr);
                    SDL_UpdateTexture(texturePtr, IntPtr.Zero, new IntPtr(p), width * 4);
                    // SDL_RenderCopy(rendererPtr, texturePtr, IntPtr.Zero, ref rect);
                    SDL_RenderCopy(rendererPtr, texturePtr, IntPtr.Zero, IntPtr.Zero);
                }
            }

            // Update screen
            SDL_RenderPresent(rendererPtr);
        }

        SDL_DestroyRenderer(rendererPtr);
        SDL_DestroyWindow(windowPtr);
        SDL_Quit();
    }
}