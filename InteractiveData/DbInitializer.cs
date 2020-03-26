using System;
using System.Threading.Tasks;
using InteractiveDomain;
using Microsoft.EntityFrameworkCore;

namespace InteractiveData
{
    public static class DbInitializer// : CreateDatabaseIfNoneExists<MarshallContext>
    {

        public static async Task SeedAsync(this MarshallContext context)
        {
            //context.Database.EnsureCreated();

            DateTimeOffset now = DateTimeOffset.UtcNow;

            // Add Array type to database, used by EntityService query
            await context.Database.ExecuteSqlCommandAsync(@"if type_id(N'Array') is null CREATE TYPE Array AS TABLE ( Item nvarchar(max) );");

            if (!await context.InteractiveAmplifiers.AnyAsync())
            {
                var interactiveAmp = new InteractiveAmplifier
                {
                    Model = "DSL",
                    Power = 20,
                    InteractiveElements = new System.Collections.Generic.List<InteractiveElement>()
                   {
                       new InteractiveElement
                       {
                            Name = "Input",
                            MeshName = "front_panel_input",
                            Panel = "Front",
                            Description = "1/4\" Jack input"

                       },
                       new InteractiveElement
                       {
                            Name = "Classic Gain",
                            MeshName = "classic_gain",
                            Panel = "Front",
                            Description = "Gain value for the op-amp"
                       },
                       new InteractiveElement
                       {
                            Name = "Classic Gain Volume",
                            MeshName = "classic_gain_volume",
                            Panel = "Front",
                            Description = "Transistors multiply the signal"
                       },
                       new InteractiveElement
                       {
                            Name = "Channel Select",
                            MeshName = "channel_select",
                            Panel = "Front",
                            Description = "A button used to select the channel"
                       },
                       new InteractiveElement
                       {
                            Name = "Ultra Gain",
                            MeshName = "ultra_gain",
                            Panel = "Front",
                            Description = "Power amp gain"
                       },
                       new InteractiveElement
                       {
                            Name = "Ultra Gain Volume",
                            MeshName = "ultra_gain_volume",
                            Panel = "Front",
                            Description = "Power amp gain volume"
                       },
                       new InteractiveElement
                       {
                            Name = "Tone Shift",
                            MeshName = "tone_shift",
                            Panel = "Front",
                            Description = "Toggles through tones"
                       },
                       new InteractiveElement
                       {
                            Name = "Equalisation Treble",
                            MeshName = "equalisation_treble",
                            Panel = "Front",
                            Description = "Cuts or boosts high frequencies"
                       },
                       new InteractiveElement
                       {
                            Name = "Equalisation Middle",
                            MeshName = "equalisation_middle",
                            Panel = "Front",
                            Description = "Cuts or boosts middle frequencies"
                       },
                       new InteractiveElement
                       {
                            Name = "Equalisation Bass",
                            MeshName = "equalisation_bass",
                            Panel = "Front",
                            Description = "Cuts or boosts low frequencies"
                       },
                       new InteractiveElement
                       {
                            Name = "Equalisation Presence",
                            MeshName = "equalisation_presence",
                            Panel = "Front",
                            Description = "Cuts or boosts your presence"
                       },
                       new InteractiveElement
                       {
                            Name = "Equalisation Resonance",
                            MeshName = "equalisation_resonance",
                            Panel = "Front",
                            Description = "Changes your resonance"
                       },
                       new InteractiveElement
                       {
                            Name = "Equalisation Reverb",
                            MeshName = "equalisation_reverb",
                            Panel = "Front",
                            Description = "Adds reverberations"
                       },
                       new InteractiveElement
                       {
                            Name = "STB",
                            MeshName = "stb",
                            Panel = "Front",
                            Description = "Standby turns output off, but keeps power running through valves"
                       },
                       new InteractiveElement
                       {
                            Name = "Output Switch",
                            MeshName = "output_switch",
                            Panel = "Front",
                            Description = "Turns output on or off"
                       },
                       new InteractiveElement
                       {
                            Name = "Power Switch",
                            MeshName = "power_switch",
                            Panel = "Front",
                            Description = "Turns power on or off"
                       },
                       new InteractiveElement
                       {
                            Name = "Power Socket",
                            MeshName = "power_socket",
                            Panel = "Back",
                            Description = "Socket to plug into mains"
                       },
                       new InteractiveElement
                       {
                            Name = "FX Loop Return",
                            MeshName = "fx_loop_return",
                            Panel = "Back",
                            Description = "Return after effects pedals"
                       },
                       new InteractiveElement
                       {
                            Name = "FX Loop Send",
                            MeshName = "fx_loop_send",
                            Panel = "Back",
                            Description = "Output to plug into any effect peadals"
                       },
                       new InteractiveElement
                       {
                            Name = "FS",
                            MeshName = "fs",
                            Panel = "Back",
                            Description = "F or S"
                       },
                       new InteractiveElement
                       {
                            Name = "Line MP3 In",
                            MeshName = "line_mp3_in",
                            Panel = "Back",
                            Description = "Backing track input"
                       },
                       new InteractiveElement
                       {
                            Name = "Emulated Out",
                            MeshName = "emulated_out",
                            Panel = "Back",
                            Description = "Audio Output to monitor"
                       },
                       new InteractiveElement
                       {
                            Name = "Loudpeaker",
                            MeshName = "loudspeaker_multimat",
                            Panel = "Back",
                            Description = "8W output to speaker"
                       },
                       new InteractiveElement
                       {
                            Name = "Loudpeaker",
                            MeshName = "loudspeaker_multimat",
                            Panel = "Back",
                            Description = "8W output to speaker"
                       },
                       new InteractiveElement
                       {
                            Name = "Loudpeaker",
                            MeshName = "loudspeaker_multimat",
                            Panel = "Back",
                            Description = "16W output to speaker"
                       },
                       new InteractiveElement
                       {
                            Name = "Cable",
                            MeshName = "cable",
                            Panel = "Back",
                            Description = "Main cable, power input"
                       }
                   }


                };
                context.InteractiveAmplifiers.Add(interactiveAmp);
                await context.SaveChangesAsync().ConfigureAwait(false);

                interactiveAmp = new InteractiveAmplifier
                {
                    Model = "Origin",
                    Power = 20,
                    InteractiveElements = new System.Collections.Generic.List<InteractiveElement>()
                    { }
                };
                context.InteractiveAmplifiers.Add(interactiveAmp);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
