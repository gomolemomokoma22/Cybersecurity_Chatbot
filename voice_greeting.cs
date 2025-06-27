namespace ai_chatbot
{
    using System.Media;
    using System;
    using System.IO;

    public class voice_greeting
    {
        //start of my constructor
        public voice_greeting()
        {
            //getting the app location
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            //checking if it is getting the directory
            Console.WriteLine(project_location);

            //replacing the bin/Debug so it can get the audio 
            string new_path = project_location.Replace("bin\\Debug\\", "voice_greeting.wav");

            //combining the wav name with the new path
            string full_path = Path.Combine(new_path, "");

            //passing the audio to the method to play
            Play_wav(full_path);


        }//end of constructor

        //method to play wav
        private void Play_wav(string full_path)
        {
            //try and catch to play the audio
            try
            {
                //playing the sound
                using (SoundPlayer sound = new SoundPlayer(full_path))
                {
                    //playing the sound till it ends
                    sound.PlaySync();

                }//end of using

            }//catching any exception error
            catch(Exception error)
            {
                //here show the error message detected
                Console.WriteLine("Error playing audio:" + error.Message);

            }//end of catch

        }//end of method to play wav


    }//end of class
     

}//end of namespace