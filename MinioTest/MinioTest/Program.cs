using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinioTest
{
    class Program
    {

        static void Main(string[] args)
        {
            var config = new AmazonS3Config
            {
                ServiceURL = "http://localhost:9000",
                ForcePathStyle=true
                
            };

            AmazonS3Client s3Client = new AmazonS3Client("minioadmin", "minioadmin", config);

            PutBucketRequest pbr = new PutBucketRequest();
            pbr.BucketName = "blobboa-10";

            S3BucketVersioningConfig sbvc = new S3BucketVersioningConfig();
            sbvc.Status = VersionStatus.Enabled;

            PutBucketVersioningRequest pbvr = new PutBucketVersioningRequest();
            pbvr.BucketName = "blobboa-10";
            pbvr.VersioningConfig = sbvc;

            PutObjectRequest por = new PutObjectRequest();
            por.BucketName = "blobboa-10";
            por.Key = "testKey";
            por.ContentBody = "test";


            try
            {
                s3Client.PutBucket(pbr);
                s3Client.PutBucketVersioning(pbvr);
                s3Client.PutObject(por);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
            }

            Console.Out.WriteLine("Done");
        }
    }
}
