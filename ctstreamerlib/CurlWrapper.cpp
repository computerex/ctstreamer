#include <curl/curl.h>
#include "CurlWrapper.h"

CurlWrapper::CurlWrapper()
{
	curl_global_init(CURL_GLOBAL_ALL);
}
CurlWrapper::~CurlWrapper()
{
	curl_global_cleanup();
}
void CurlWrapper::uploadFile(char * url, char * fpath, char * fname)
{
	initop();
	struct curl_httppost *formpost=NULL;
	struct curl_httppost *lastptr=NULL;
	struct curl_slist *headerlist=NULL;
	static const char buf[] = "Expect:";

	/* Fill in the file upload field */
	curl_formadd(&formpost,
		&lastptr,
		CURLFORM_COPYNAME, "file",
		CURLFORM_FILE, fpath,
		CURLFORM_END);
	curl_formadd(&formpost,
               &lastptr,
               CURLFORM_COPYNAME, "filename",
               CURLFORM_COPYCONTENTS, fpath,
               CURLFORM_END);
	// append the Expect header with no right side to disable
	headerlist = curl_slist_append(headerlist, buf);
	curl_easy_setopt(curl, CURLOPT_URL, url);
	curl_easy_setopt(curl, CURLOPT_HTTPHEADER, headerlist);
	curl_easy_setopt(curl, CURLOPT_HTTPPOST, formpost);

	res = curl_easy_perform(curl);
	if(res != CURLE_OK)
		fprintf(stderr, "curl_easy_perform() failed: %s\n", curl_easy_strerror(res));

	curl_easy_cleanup(curl);

	/* then cleanup the formpost chain */
	curl_formfree(formpost);
	/* free slist */
	curl_slist_free_all (headerlist);
}
void CurlWrapper::initop()
{
	curl = curl_easy_init();
	// Read cookies from a previous session
	curl_easy_setopt( curl, CURLOPT_COOKIEFILE, "cookie.txt" );
	// Save cookies from *this* session
	curl_easy_setopt( curl, CURLOPT_COOKIEJAR, "cookie.txt" );
}
void CurlWrapper::downloadFile(char * url, char * fname)
{
	initop();
	FILE *fp;
    fp = fopen(fname,"wb");
    curl_easy_setopt(curl, CURLOPT_URL, url);
    curl_easy_setopt(curl, CURLOPT_WRITEFUNCTION, write_data);
    curl_easy_setopt(curl, CURLOPT_WRITEDATA, fp);
    res = curl_easy_perform(curl);
	curl_easy_cleanup(curl);
    fclose(fp);
}

void CurlWrapper::post(char* url, char* query)
{
	initop();
	curl_easy_setopt(curl, CURLOPT_URL, url);
	curl_easy_setopt(curl, CURLOPT_POSTFIELDS, query);
	res=curl_easy_perform(curl);
	if ( res != CURLE_OK )
		fprintf(stderr, "curl_easy_perform() failed %s\n", curl_easy_strerror(res));
	curl_easy_cleanup(curl);
}
void CurlWrapper::get(char* url)
{
	initop();
	curl_easy_setopt(curl, CURLOPT_URL, url); 
    curl_easy_setopt(curl, CURLOPT_FOLLOWLOCATION, 1L);
	res = curl_easy_perform(curl);
	curl_easy_cleanup(curl);
}
size_t write_data(void *ptr, size_t size, size_t nmemb, FILE *stream) {
    size_t written = fwrite(ptr, size, nmemb, stream);
    return written;
}

